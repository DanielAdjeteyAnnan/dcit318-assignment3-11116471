namespace Healthcare
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new HealthSystemApp();

            app.SeedData();
            app.BuildPrescriptionMap();
            app.PrintAllPatients();

            // Example: print prescriptions for patient with ID 2
            app.PrintPrescriptionsForPatient(2);
        }
    }
}
