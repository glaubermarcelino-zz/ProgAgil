using System.Collections.Generic;

namespace reclameja.api.Models
{
    public enum EChartType{
   BarChart,
     PointChart,
     LineChart,
     DonutChart,
     RadialGaugeChart,
     RadarChart

    }
    public class DashboardItem
    {
        public string Name { get; set; }
        public EChartType Type { get; set; }
        public List<Serie> Series { get; set; }
    }
}