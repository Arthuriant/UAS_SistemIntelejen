# Fabrica de Pastillas - Simulasi VR

<p align="center">
  <img width="900"  alt="Screenshot 2025-11-02 111321" src="https://github.com/user-attachments/assets/57af2442-7348-467a-8619-b94e44cfa7df" />
</p>

Sebuah game simulasi **Virtual Reality (VR)** yang imersif, dibuat menggunakan **Unity Engine**. Dalam game ini, pemain akan merasakan pengalaman menjalankan pabrik rahasia, meracik, memproses, dan menjual produk (obat-obatan) melalui serangkaian alur produksi yang interaktif.

Proyek ini mengeksplorasi mekanika interaksi VR, manajemen proses langkah-demi-langkah, dan sistem ekonomi sederhana.

---

## ✨ Fitur Utama

* **🧪 Interaksi VR Imersif:** Dibangun dari dasar untuk VR. Ambil, lemparkan, dan manipulasi objek di dunia game secara langsung menggunakan tangan virtual Anda.
* **🔄 Alur Produksi Lengkap:** Ikuti 6 tahapan proses produksi yang jelas, mulai dari bahan mentah hingga produk jadi.
* **📜 Sistem Resep (Resep):** Ikuti resep di sebelah kiri untuk mengubah satu item menjadi item lain, seperti yang ditunjukkan pada panel "RESEP".
* **💰 Simulasi Ekonomi Sederhana:** Jual produk akhir Anda di stasiun "Selling" untuk mendapatkan uang dan melanjutkan siklus produksi.

## 🔄 Alur Kerja Simulasi

Gameplay inti berpusat pada alur kerja 6 langkah. Pemain harus menyelesaikan setiap tahap secara berurutan untuk berhasil membuat produk:

1.  **Mixing (Mencampur):** Menggabungkan bahan-bahan awal di dalam gelas kimia (beaker).
2.  **Burning (Memanaskan):** Memanaskan campuran di atas pembakar Bunsen.
3.  **Grilling (Memanggang):** Mengeringkan atau memanggang produk setengah jadi di dalam oven/panggangan.
4.  **Hammering (Menghancurkan):** Menghancurkan hasil panggangan menjadi bentuk kristal.
5.  **Packaging (Mengemas):** Mengemas kristal ke dalam botol atau kemasan akhir.
6.  **Selling (Menjual):** Menempatkan produk jadi di konter penjualan untuk mendapatkan uang.

<p align="center">
  <img width="900" alt="image" src="https://github.com/user-attachments/assets/1d93a4cb-704e-4df1-9e07-75b628f0a2f8" />
</p>

## 🛠️ Tumpukan Teknologi (Tech Stack)

| Teknologi | Deskripsi |
| :--- | :--- |
| **Unity Engine** | *Game engine* utama yang digunakan untuk membangun lingkungan, fisika, dan logika game. |
| **C# (C-Sharp)** | Bahasa pemrograman yang digunakan untuk semua *scripting* gameplay dan interaksi. |
| **Unity XR Toolkit** | Mengelola *rig* VR, input controller, dan interaksi *grab/throw*. |

---

## 🚀 Prasyarat & Cara Menjalankan

### Prasyarat Sistem

* PC/Laptop yang *VR-Ready*.
* Headset VR yang kompatibel (misalnya, Oculus Quest, Rift S, HTC Vive, Valve Index).
* Unity Hub dan **Unity Editor**.

### Menjalankan Proyek

1.  **Clone Repositori**
    ```sh
    git clone [URL_REPOSITORI_ANDA]
    ```

2.  **Buka di Unity Hub**
    * Buka Unity Hub Anda.
    * Klik "Add project from disk".
    * Arahkan ke folder yang baru saja Anda clone.

3.  **Jalankan di Editor (VR)**
    * Pastikan Headset VR Anda terhubung ke PC dan layanan (seperti Oculus Link atau SteamVR) berjalan.
    * Buka *scene* utama 'methSimulation2' dari folder `Assets/Scenes`.
    * Tekan tombol **Play** di Unity Editor.
    * Kenakan headset Anda untuk memulai simulasi.

---

## 📸 Galeri Tambahan

| Lantai Utama | Lantai Dapur |
| :---: | :---: |
| Bertemakan restoran parodi lost polos hermanos serial breaking bad | Area penghubung lantai utama dengan lantai rahasia |
| <img width="450" alt="Screenshot 2025-11-02 121945" src="https://github.com/user-attachments/assets/d02c9da1-567b-483d-8c7a-da73913ae52d" /> | <img width="450" alt="Screenshot 2025-11-02 122004" src="https://github.com/user-attachments/assets/612cab96-c9b4-453f-a5cf-e074b50b3056" />|

| Lantai Rahasia | Lantai Rahasia |
| :---: | :---: |
| Tempat untuk meracik obat obatan rahasia | Tempat untuk meracik obat obatan rahasia |
| <img width="450" alt="Screenshot 2025-11-02 122021" src="https://github.com/user-attachments/assets/48de48c4-e9ad-4d42-8157-b36a32713d32" /> | <img width="450" alt="Screenshot 2025-11-02 122044" src="https://github.com/user-attachments/assets/14ce39da-b6a9-4b5e-8011-c5d2c40c2975" />|
