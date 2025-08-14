using System;
using System.Collections.Generic;
using System.Linq;

namespace Healthcare
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo = new();
        private Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            _patientRepo.Add(new Patient(1, "John Doe", 30, "Male"));
            _patientRepo.Add(new Patient(2, "Jane Smith", 25, "Female"));
            _patientRepo.Add(new Patient(3, "Michael Johnson", 40, "Male"));

            _prescriptionRepo.Add(new Prescription(101, 1, "Paracetamol", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Amoxicillin", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(104, 3, "Vitamin C", DateTime.Now));
            _prescriptionRepo.Add(new Prescription(105, 2, "Cough Syrup", DateTime.Now.AddDays(-2)));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap = _prescriptionRepo
                .GetAll()
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("\n=== All Patients ===");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            Console.WriteLine($"\n=== Prescriptions for Patient ID {id} ===");
            if (_prescriptionMap.ContainsKey(id))
            {
                foreach (var prescription in _prescriptionMap[id])
                {
                    Console.WriteLine(prescription);
                }
            }
            else
            {
                Console.WriteLine("No prescriptions found for this patient.");
            }
        }
    }
}
