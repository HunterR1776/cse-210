using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Line cook";
        job1._company = "Burger king";
        job1._startYear = 2016;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "devops engineer";
        job2._company = "Valiantys";
        job2._startYear = 2022;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Dylan Rhoads";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}