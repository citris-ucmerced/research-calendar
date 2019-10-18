using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CITRIS
{
    public static class BuildCalendar
    {
        [FunctionName("BuildCalendar")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            /* Fetch CSV from server */
            /* ~~~~~~~~~~~~~~~~~~~~~ */

            //Implementation TDB
            //Implementation TDB
            //Implementation TDB
            
            //var csv_text = document.getElementById("message").value;

            /* Run logic to interpolate event dates */
            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
            string[] entries = csv_text.split('\n');
            var events_injected = [];

            /* Iterate over rows of */
            for (var i = 0; i < entries.length; i++) {
                
                /* Isolate elements per row */
                string[] fields = entries[i].split(',');

                string name = fields[0];
                var value = fields[3];
                var extra_time = 2;
                if (value > 250000) extra_time++;
                if (value > 500000) extra_time++;
                if (value > 1000000) extra_time++;
                if (value > 2000000) extra_time++;

                // TODO:: Redo below logic for C#, ideally a little cleaner and more scalable :) 

                // var due_date = new Date(fields[2]);

                // var init_review_date = new Date(due_date.getTime())
                // init_review_date.setDate(due_date.getDate() - 8 - extra_time);

                // var end_review_date = new Date(due_date.getTime())
                // end_review_date.setDate(due_date.getDate() - 8);

                // var srs_week_start_date = new Date(due_date.getTime())
                // srs_week_start_date.setDate(due_date.getDate() - 7);

                // var srs_week_end_date = new Date(due_date.getTime())
                // srs_week_end_date.setDate(due_date.getDate() - 1);

                // var final_review_date = new Date(due_date.getTime())
                // final_review_date.setDate(due_date.getDate() - 1);

                // var srs_week_start_date = new Date(due_date.getTime())
                // srs_week_start_date.setDate(due_date.getDate() - 7);
                
                /* Add Deadline */
                events_injected.push({
                    title: fields[0] + " " + fields[1] + " Deadline!",//,
                    start: due_date,
                    color: 'red'
                })
                /* Add Final Review */
                events_injected.push({
                    title: fields[0] + " " + fields[1] + " Final Review by " + fields[4],//,
                    start: final_review_date,
                    end: due_date,
                    color: 'brown'
                })
                /* Add SRS Review */
                events_injected.push({
                    title: fields[0] + " " + fields[1] + " SRS Review",//,
                    start: srs_week_start_date,
                    end: due_date,
                    color: 'orange'
                })
                /* Add Initial Review */
                events_injected.push({
                    title: fields[0] + " " + fields[1] + " Initial Review by " + fields[4],//,
                    start: init_review_date,
                    end: end_review_date,
                    color: 'blue'
                })
            }
            
            /* Push to Outlook via API */
            /* ~~~~~~~~~~~~~~~~~~~~~~~ */

            //Implementation TDB
            //Implementation TDB
            //Implementation TDB
            
        }
    }
}
