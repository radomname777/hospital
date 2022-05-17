using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Travmatologiya
    {
        private Doctor[] doctor { get; set; } = new Doctor[] {new Doctor("Seide","Emirova","Q",43,"Travmatologiya"),
                new Doctor("Zahid","Seferov","K",47,"Travmatologiya"),
                new Doctor("Idrak","Hesenov","K",64,"Travmatologiya")};
        public   App app { get; set; } = new App();
        public void Start(string filename = "travmatologiya")
        {
            try { using FileStream fs1 = new FileStream(filename + ".bin", FileMode.Open, FileAccess.Read); }
            catch (Exception) { app.Yaz(doctor, filename); }
            finally {
                bool isokay = app.ResetTime(filename);
                if (isokay) app.Yaz(doctor, filename);
                app.oxu(filename, doctor.Length); }
        }

    }
}
