using TP_MODUL9_103022400042;

namespace TP_MODUL9_103022400042
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inisialisasi Config
            CovidConfig covidConfig = new CovidConfig();

            // Jalankan pengecekan pertama
            JalankanPengecekan(covidConfig);

            Console.WriteLine("\n--- Mengubah Satuan Suhu (Memanggil UbahSatuan) ---");
            covidConfig.UbahSatuan();

            // Jalankan pengecekan kedua setelah satuan diubah
            JalankanPengecekan(covidConfig);
        }

        static void JalankanPengecekan(CovidConfig covidConfig)
        {
            Console.WriteLine($"\nBerapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}: ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool kondisiSuhuTerpenuhi = false;

            // Pengecekan Kondisi Suhu
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                {
                    kondisiSuhuTerpenuhi = true;
                }
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                {
                    kondisiSuhuTerpenuhi = true;
                }
            }

            // Pengecekan Kondisi Hari
            bool kondisiHariTerpenuhi = hari < covidConfig.config.batas_hari_demam;

            // Output Hasil
            if (kondisiSuhuTerpenuhi && kondisiHariTerpenuhi)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }
        }
    }
}