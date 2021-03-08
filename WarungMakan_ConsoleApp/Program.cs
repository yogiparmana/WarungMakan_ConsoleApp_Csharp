using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace WarungMakan_ConsoleApp
{
    class Program
    {
        private static List<string> namaList = new List<string>();
        private static List<int> hargaList = new List<int>();
        private static List<string> dataUser = new List<string>();


        static void Main(string[] args)
        {
            ConsoleColor backgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = backgroundColor;
            
            login();
        }


        public static void login()
        {
            string meja = "";
            bool loop = true;
           
            string pilih;
            Console.Write("Masukkan Nama Anda : ");
            String nama = Console.ReadLine();
            Console.WriteLine(
                "-------Meja-------\n" +
                "1.Mawar\n" +
                "2. Melati\n" +
                "3.Kamboja\n" +
                "4.Lily\n"
                );

            do
            {
                Console.Write("Pilih Meja anda : ");
                pilih = Console.ReadLine();
                switch (pilih)
                {
                    case "1":
                        meja = "Mawar";
                        loop = false;
                        break;
                    case "2":
                        meja = "Melati";
                        loop = false;
                        break;
                    case "3":
                        meja = "Kamboja";
                        loop = false;
                        break;
                    case "4":
                        meja = "Lily";
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Input Salah");
                        loop = true;
                        break;
                }
            } while (loop == true);
            Console.Clear();
            dataUser.Add(nama);
            dataUser.Add(meja);
            MenuUtama(nama);

        }
        public static void MenuUtama(string nama)
        {
            string pilih;
            bool loop;
            string[] menuMakanan = new string[6];
            string[] menuMinuman = new string[6];
            string[] menuSnack = new string[6];
            string[] desc = new string[6];
            int[] harga = new int[6];
            int[] stok = new int[6];

            Console.WriteLine("Selamat Datang " + nama);
            Console.WriteLine(
               "=================\n" +
               "-------Menu-------\n" +
               "1.Makanan\n" +
               "2.Minuman\n" +
               "3.Snack\n"
               );
            do
            {
                Console.Write("Silakan Pilih Menu anda : ");
                pilih = Console.ReadLine();
                switch (pilih)
                {
                    case "1":
                        DataMenu(menuMakanan, "Makanan", harga, desc, stok, namaList, hargaList);
                        loop = false;
                        break;
                    case "2":
                        DataMenu(menuMinuman, "Minuman", harga, desc, stok, namaList, hargaList);
                        loop = false;
                        break;
                    case "3":
                        DataMenu(menuSnack, "Snack", harga, desc, stok, namaList, hargaList);
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Input Salah");
                        loop = true;
                        break;
                }
            } while (loop == true);
        }

        public static void DataMenu(string[] namaMenu, string nama, int[] harga, string[] desc, int[] stok, List<string> namaList1, List<int> hargaList1)
        {
            namaList = namaList1;
            hargaList = hargaList1;

            int loop2;
            String pilih;
            BuatHarga(harga, nama, stok);

            GenerateMenu(namaMenu, nama, desc);
            

            back:
            Console.Clear();
            Console.WriteLine(
             "=================\n" +
             "-------" + nama + "-------\n"
             );
            Console.WriteLine("No ||\tNama " + nama + " ||\tHarga ||\tStok");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((i + 1) + ". ||\t" + namaMenu[i] + " ||\t\t" + harga[i] + " ||\t" + stok[i]);

            }
            do
            {
                loop2 = 1;
                Console.WriteLine("Lihat detail ketik 0 :");
                Console.Write("Pilih menu Anda : ");
                pilih = Console.ReadLine();
                switch (pilih)
                {
                    case "1":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[0]);
                        hargaList.Add(harga[0]);
                        loop2 = Konfirmasi();
                        break;
                    case "2":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[1]);
                        hargaList.Add(harga[1]);
                        loop2 = Konfirmasi();
                        break;
                    case "3":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[2]);
                        hargaList.Add(harga[2]);
                        loop2 = Konfirmasi();
                        break;
                    case "4":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[3]);
                        hargaList.Add(harga[3]);
                        loop2 = Konfirmasi();
                        break;
                    case "5":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[4]);
                        hargaList.Add(harga[4]);
                        loop2 = Konfirmasi();
                        break;
                    case "6":
                        Console.WriteLine("Berhasil Di Pesan...");
                        namaList.Add(namaMenu[5]);
                        hargaList.Add(harga[5]);
                        loop2 = Konfirmasi();
                        break;
                    case "0":
                        Console.Write("Pilih Detail Makanan Anda : ");
                        pilih = Console.ReadLine();
                        Console.Clear();
                        int convert = int.Parse(pilih);
                        string[] arr = namaMenu[convert].Split('_');
                        Console.WriteLine("Detail " + arr[0]);
                        Console.WriteLine("Nama " + arr[0] + " \t: " + namaMenu[convert]);
                        Console.WriteLine("Harga \t\t: " + harga[convert]);
                        Console.WriteLine("Stok \t\t: " + stok[convert]);
                        Console.WriteLine("Description\t : " + desc[convert]);
                        Console.WriteLine("============================");
                        Console.WriteLine("Press Enter Untuk Kembali...");

                        ConsoleKeyInfo key = Console.ReadKey();

                        if (key.Key.Equals(ConsoleKey.Enter))
                        {
                            goto back;
                        }
                        Console.ReadLine();
                        loop2 = 2;
                        break;
                    default:
                        Console.WriteLine("Input Salah");
                        loop2 = 1;
                        break;
                }
            } while (loop2 == 1);
            Console.Clear();
            int total = Detail_Pesanan(nama, namaList, hargaList);
            int tmb = TambahPesanan();
            if (tmb == 1)
            {
                Console.Clear();
                MenuUtama(nama);
            }
            if (tmb == 2)
            {
                Pembayaran(total);
            }



        }
        public static void GenerateMenu(string[] namaMenu, string nama, string[] desc)
        {
            for (int i = 0; i < 6; i++)
            {
                namaMenu[i] = nama + "_" + i;
                desc[i] = "ini adalah " + nama + "yang terbuat dari blabla";
            }
        }

        public static void BuatHarga(int[] harga, string nama, int[] stok)
        {
            if (nama == "Makanan")
            {
                harga[0] = 20000;
                harga[1] = 10000;
                harga[2] = 25000;
                harga[3] = 15000;
                harga[4] = 7000;
                harga[5] = 20000;

                stok[0] = 10;
                stok[1] = 9;
                stok[2] = 5;
                stok[3] = 7;
                stok[4] = 4;
                stok[5] = 1;
            }
            if (nama == "Minuman")
            {
                harga[0] = 2000;
                harga[1] = 3000;
                harga[2] = 5000;
                harga[3] = 7000;
                harga[4] = 6000;
                harga[5] = 10000;

                stok[0] = 5;
                stok[1] = 4;
                stok[2] = 20;
                stok[3] = 3;
                stok[4] = 4;
                stok[5] = 5;
            }
            if (nama == "Snack")
            {
                harga[0] = 1000;
                harga[1] = 500;
                harga[2] = 3000;
                harga[3] = 2000;
                harga[4] = 1500;
                harga[5] = 2000;

                stok[0] = 5;
                stok[1] = 8;
                stok[2] = 10;
                stok[3] = 16;
                stok[4] = 27;
                stok[5] = 15;
            }

        }

        public static void Detail(string nama, int harga, string desc, int stok)
        {
            
        }


        public static int Konfirmasi()
        {
            int loop = 0;
            string pilih;
            bool loop1;
            do
            {
                Console.WriteLine("==========================");
                Console.Write("Ingin Pesan Lagi? (1/Y = Iya, 2/T = Tidak) : ");
                pilih = Console.ReadLine();
                if (pilih == "1" || pilih == "Y" || pilih == "y")
                {
                    loop = 1;

                    loop1 = true;
                }
                else if (pilih == "2" || pilih == "T" || pilih == "t")
                {
                    loop = 2;
                    loop1 = true;
                }
                else
                {
                    Console.WriteLine("input salah");
                    loop1 = false;
                }
            } while (loop1 == false);
            Console.WriteLine(loop);
            return loop;

        }

        public static int Detail_Pesanan(String nama, List<String> namaList, List<int> hargaList)
        {
            int total = 0;
            Console.WriteLine("Pemesanan : ");
            Console.WriteLine("===================== ");
            Console.WriteLine("No ||\tNama " + nama + " ||\tHarga");
            for (int i = 0; i < namaList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". ||\t" + namaList[i] + " ||\t" + hargaList[i]);
                total += hargaList[i];
            }

            Console.WriteLine("===================== ");
            Console.WriteLine("Jumlah : " + namaList.Count + "||\t\t Total : " + total);
            return total;

        }
        public static int TambahPesanan()
        {
            int loop = 0;
            string pilih;
            bool loop1;
            do
            {
                Console.WriteLine("==========================");
                Console.Write("Tambah Pesanan? (1/Y = Iya, 2/T = Tidak) : ");
                pilih = Console.ReadLine();
                if (pilih == "1" || pilih == "Y" || pilih == "y")
                {
                    loop = 1;

                    loop1 = true;
                }
                else if (pilih == "2" || pilih == "T" || pilih == "t")
                {
                    loop = 2;
                    loop1 = true;
                }
                else
                {
                    Console.WriteLine("input salah");
                    loop1 = false;
                }
            } while (loop1 == false);
            Console.WriteLine(loop);
            return loop;

        }

        public static void Pembayaran(int total)
        {
            Console.Clear();
            int kembalian;
            int loop = 1;
            Console.WriteLine("Pembayaranan : ");
            Console.WriteLine("Nama : "+dataUser[0]);
            Console.WriteLine("Meja : " + dataUser[1]);
            Console.WriteLine("===================== ");
            Console.WriteLine("Total Belanjaan anda : Rp." + total);
            do
            {

                Console.WriteLine("-------------------------- ");
                Console.Write("Masukkan Jumlah Uang : Rp.:");
                string bayar = Console.ReadLine();
                int parse = -1;
                if (int.TryParse(bayar, out parse))
                {
                    kembalian = total - int.Parse(bayar);
                    if (kembalian > 0)
                    {
                        Console.WriteLine("Uang Anda Kurang Lagi Rp." + kembalian * -1);
                        loop = 2;
                    }
                    else
                    {
                        Console.WriteLine("Kembalian Anda Rp." + kembalian);
                        loop = 1;
                    }
                }
                else
                {
                    Console.WriteLine("Input Harus Number!");
                    loop = 2;
                }
            } while (loop == 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("----Terimakasih----");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;



        }



  
    }
}
