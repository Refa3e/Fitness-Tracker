using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FitnessTrackerApp.View
{
    public partial class DashBoardForm : UserControl
    {
        private readonly string username;
        private readonly WeightEntryService weightService = new WeightEntryService();

        public DashBoardForm(string username)
        {
            this.username = username;
            InitializeComponent();
            ShowChart();
        }

        private void ShowChart()
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            chart.ChartAreas.Clear();

            List<WeightEntry> entries = weightService.GetEntriesAscending(username);

            List<WeightEntry> uniqueEntries = new List<WeightEntry>();

            for (int i = 0; i < entries.Count; i++)
            {
                WeightEntry current = entries[i];

                if (i == entries.Count - 1)
                {
                    uniqueEntries.Add(current);
                    break;
                }

                WeightEntry next = entries[i + 1];

                if (current.Date.Date != next.Date.Date)
                {
                    uniqueEntries.Add(current);
                }
            }

            int start = Math.Max(uniqueEntries.Count - 20, 0);
            List<WeightEntry> last20 = new List<WeightEntry>();

            for (int i = start; i < uniqueEntries.Count; i++)
            {
                last20.Add(uniqueEntries[i]);
            }

            if (last20.Count == 0)
            {
                Title noDataTitle = new Title
                {
                    Text = "No weight data available yet",
                    Font = new Font("Arial", 14, FontStyle.Regular)
                };
                chart.Titles.Add(noDataTitle);
                return;
            }

            decimal minWeight = last20[0].Weight;
            foreach (WeightEntry e in last20)
            {
                if (e.Weight < minWeight)
                {
                    minWeight = e.Weight;
                }
            }

            ChartArea area = new ChartArea();
            area.AxisX.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisX.LabelStyle.Format = "MMM dd";
            area.AxisY.Minimum = (double)(minWeight - 2);
            area.AxisX.Title = "Date";
            area.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            area.AxisY.Title = "Weight (kg)";
            area.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chart.ChartAreas.Add(area);

            Title title = new Title
            {
                Text = "Weight Progress Chart",
                Font = new Font("Arial", 16, FontStyle.Bold)
            };
            chart.Titles.Add(title);

            Series series = new Series
            {
                Name = "Weight",
                ChartType = SeriesChartType.Line,
                Color = Color.DodgerBlue,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                MarkerColor = Color.DodgerBlue
            };

            foreach (WeightEntry e in last20)
            {
                series.Points.AddXY(e.Date, e.Weight);
            }

            chart.Series.Add(series);
        }

        private void chart_Click(object sender, EventArgs e)
        {
            // Empty on purpose
        }
    }
}