using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Pediatriy
    {
        private Doctor[] doctor { get; set; } = new Doctor[] {new Doctor("Vaqif","Abdullayev","K",32,"Pediatriy"),
                new Doctor("Arzu","Huseynova","Q",59,"Pediatriy"),
                new Doctor("Xeyale","Quliyeva","Q",42,"Pediatriy")};
        public App app { get; set; } = new App();
        public void Start(string filename = "pediatriya")
        {
            try { using FileStream fs1 = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read); }
            catch (Exception) { app.Yaz(doctor, filename); }
            finally
            {   bool isokay = app.ResetTime(filename);
                if (isokay) app.Yaz(doctor, filename);
                app.oxu(filename, doctor.Length);}
        }

    }
}
