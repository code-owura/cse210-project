using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Petroleum Engineer";
        job1._company = "GNPC";
        job1._startYear = 2026;
        job1._endYear = "NA";

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Amazon";
        job2._startYear = 2028;
        job2._endYear = "NA";

        Resume myResume = new Resume();
        myResume._name = "Kwadwo Ahenkan";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}