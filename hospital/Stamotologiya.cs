using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{

    class Stamotologiya
    {
        private Doctor[] doctor { get; set; } = new Doctor[] {new Doctor("Gunay","Cebrayilova","Q",43,"Stamotologiya"),
                new Doctor("Olman","Abbasov","K",47,"Stamotologiya"),
                new Doctor("Sevinc","Abasova","Q",64,"Stamotologiya")};
        public App app { get; set; } = new App();
        public void Start(string filename = "Stamotologiya")
        {
            try { using FileStream fs1 = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read); }
            catch (Exception) { app.Yaz(doctor, filename); }
            finally { bool isokay = app.ResetTime(filename);
                if (isokay) app.Yaz(doctor, filename);
                app.oxu(filename, doctor.Length);
            }
            
        }
 

    }
}
