using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTCPClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private CancellationTokenSource cancellationTokenSource;
        private List<Dictionary<string, object>> messages;
        private int currentCommandIndex = 0;
        private Dictionary<string, int> machineActivity;

        public Form1()
        {
            InitializeComponent();
            InitializeMessages();
            InitializeMachineActivity();
        }
        // Initialize the list of messages to be sent to the server
        private void InitializeMessages()
        {
            messages = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "pickFromEP" } },
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "placeToMP" } },
                new Dictionary<string, object> { { "device", "lstat" }, { "routine", "rotateTable" } },
                new Dictionary<string, object> { { "device", "lstat" }, { "routine", "moveIn" } },
                new Dictionary<string, object> { { "device", "crane" }, { "routine", "pickFromLS" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "openDoors" } },
                new Dictionary<string, object> { { "device", "crane" }, { "routine", "placeToMC" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "closeDoors" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "rotateTable" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "rotateTable" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "openDoors" } },
                new Dictionary<string, object> { { "device", "crane" }, { "routine", "pickFromMC" } },
                new Dictionary<string, object> { { "device", "mcent" }, { "routine", "closeDoors" } },
                new Dictionary<string, object> { { "device", "crane" }, { "routine", "placeToLS" } },
                new Dictionary<string, object> { { "device", "lstat" }, { "routine", "rotateTable" } },
                new Dictionary<string, object> { { "device", "lstat" }, { "routine", "moveOut" } },
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "pickFromMP" } },
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "placeToWP" } },
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "pickFromWP" } },
                new Dictionary<string, object> { { "device", "robot" }, { "routine", "placeToEP" } },
            };
        }
        // Initialize the machine activity dictionary to track the number of tasks each
        private void InitializeMachineActivity()
        {
            machineActivity = new Dictionary<string, int>
            {
                { "robot", 0 },
                { "lstat", 0 },
                { "crane", 0 },
                { "mcent", 0 }
            };
        }
        // Highlight the panel corresponding to the active machine
        private void HighlightMachine(string device)
        {
            robotPanel.BackColor = device == "robot" ? Color.Green : Color.Gray;
            lstatPanel.BackColor = device == "lstat" ? Color.Green : Color.Gray;
            cranePanel.BackColor = device == "crane" ? Color.Green : Color.Gray;
            mcentPanel.BackColor = device == "mcent" ? Color.Green : Color.Gray;
        }
        // Event handler for the Start button click event
        private async void StartButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = new CancellationTokenSource();
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            Log("Attempting to connect to server...");
            currentCommandIndex = 0;
            await ProcessMessages(cancellationTokenSource.Token);
        }
        // Event handler for the Stop button click event
        private void StopButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            Log("Stopping TCP communication...");
            StopConnection();
            StartButton.Enabled = true;
            StopButton.Enabled = false;
        }
        // Process the list of messages and send them to the server (loops through all tasks 10 times) 
        private async Task ProcessMessages(CancellationToken token)
        {
            try
            {
                for (int loop = 0; loop < 10; loop++) // Outer loop to repeat tasks 10 times
                {
                    currentCommandIndex = 0; // Reset command index for each loop
                    while (currentCommandIndex < messages.Count)
                    {
                        if (token.IsCancellationRequested) break;

                        // Ensure we create a fresh connection for each message
                        client?.Close();
                        client = new TcpClient("127.0.0.1", 30000);
                        stream = client.GetStream();
                        Log("Connected to server.");

                        var message = messages[currentCommandIndex];

                        // Highlight the machine in use
                        HighlightMachine(message["device"].ToString());

                        // Increment the machine activity count
                        machineActivity[message["device"].ToString()]++;

                        // Serialize message
                        string request = JsonSerializer.Serialize(message) + "\n";

                        // Start stopwatch
                        var stopwatch = Stopwatch.StartNew();

                        // Send message
                        byte[] data = Encoding.UTF8.GetBytes(request);
                        await stream.WriteAsync(data, 0, data.Length, token);
                        await stream.FlushAsync(token);

                        // Remove outer braces and quotes from the JSON string and add spaces after keys
                        string formattedRequest = request.Trim().TrimStart('{').TrimEnd('}').Replace("\"device\":", "device: ").Replace("\"routine\":", " routine: ").Replace("\"", "");
                        Log($"SEND: {formattedRequest}");

                        var buffer = new byte[4096];
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                        // Stop stopwatch
                        stopwatch.Stop();

                        // Calculate and log the percentages
                        int totalTasks = machineActivity["robot"] + machineActivity["lstat"] + machineActivity["crane"] + machineActivity["mcent"];
                        foreach (var machine in machineActivity.Keys)
                        {
                            double percentage = (double)machineActivity[machine] / totalTasks * 100;
                            UpdateMachinePercentageLabel(machine, percentage);
                        }

                        if (bytesRead > 0)
                        {
                            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            // Remove outer braces and quotes from the JSON string and remove the "result" part
                            string formattedResponse = response.Trim().TrimStart('{').TrimEnd('}').Replace("\"result\":", "").Replace("\"", "").Trim().TrimStart(',').Trim();
                            Log($"FULL SERVER RESPONSE: {formattedResponse}");
                            Log($"Task Duration: {stopwatch.ElapsedMilliseconds} ms");
                            currentCommandIndex++;
                        }
                        else
                        {
                            Log("No response received from server.");
                            break;
                        }

                        // Fully close stream after each message
                        StopConnection();
                        await Task.Delay(500, token);
                    }
                }

            }
            catch (Exception ex)
            {
                Log($"Connection error: {ex.Message}");
            }
            finally
            {
                Log("All tasks completed. Closing connection...");
                StopConnection();
            }
        }

        // Updates the machines' activity percentage labels after each task
        private void UpdateMachinePercentageLabel(string machine, double percentage)
        {
            string percentageText = $"{percentage:F2}%";
            switch (machine)
            {
                case "robot":
                    robotPercentageTextBox.Text = percentageText;
                    break;
                case "lstat":
                    lstatPercentageTextBox.Text = percentageText;
                    break;
                case "crane":
                    cranePercentageTextBox.Text = percentageText;
                    break;
                case "mcent":
                    mcentPercentageTextBox.Text = percentageText;
                    break;
            }
        }
        // Stops connection with server when stop button is clicked
        private void StopConnection()
        {
            stream?.Close();
            client?.Close();
            stream = null;
            client = null;
        }
        // Log messages to the ListBox control
        private void Log(string message)
        {
            if (LogListBox.InvokeRequired)
            {
                LogListBox.Invoke((Action)(() => Log(message)));
            }
            else
            {
                LogListBox.Items.Add(message);
                LogListBox.TopIndex = LogListBox.Items.Count - 1;
            }
        }
    }
}



