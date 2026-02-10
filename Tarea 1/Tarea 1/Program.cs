
using Tarea_1;

    Student student1 = new Student();
    student1.Id = 1;
    student1.Name = "Maicol";
    student1.LastName = "Suarez";
    student1.studentenrollment = 20250995;
    student1.status = StatusStudent.Active;


    Teacher Teacher1 = new Teacher();
    Teacher1.Id = 1;
    Teacher1.Name = "Starling";
    Teacher1.LastName = "Germosen";
    Teacher1.Salary = 50000;
    Teacher1.specialism = "Art Teacher";

    Administrator Admin1 = new Administrator();
    Admin1.Id = 1;
    Admin1.Name = "Juanito";
    Admin1.LastName = "De la concha";
    Admin1.Departament = "Security";
    Admin1.Salary = 25000; 

    Console.WriteLine($"Student: {student1.Name} {student1.LastName}");
    Console.WriteLine($"Teacher: {Teacher1.Name} {Teacher1.LastName}");
    Console.WriteLine($"Admin: {Admin1.Name} {Admin1.LastName}");

Console.WriteLine("Salir");
Console.ReadKey();

