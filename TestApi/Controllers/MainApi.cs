using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {
        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntListWork(List<double> lint)
        {
            List<string> slist = new List<string>();

            double mean = 0;
            double variance = 0;
            double standard_deviation = 0;
            double sum = 0;

            double temp = 0;
            int counter = 0;
            int loop = 0;

            for (counter = 0; counter < lint.Count; counter++)
            {
                System.Console.WriteLine(LogObject(lint[counter]));
            }
            return Accepted(lint);

            lint.Sort();

            foreach (int i in lint)
            {
                loop++;

                for (counter = 0; counter < lint.Count; counter++)
                {
                    sum += lint[counter];
                }

                mean = sum / (lint.Count - 0);

                for (counter = 0; counter < lint.Count; counter++)
                {
                    temp += Math.Pow((lint[counter] - mean), 2);
                }

                variance = temp / (lint.Count - 0);

                standard_deviation = Math.Sqrt(variance);

                slist.Add("Elements: " + loop + " Current Standard Deviation: " + standard_deviation);
            }

            return slist;
        }
        double LogObject(double input)
        {
            System.Diagnostics.Debug.WriteLine(input);
            return input;
        }
    }
}