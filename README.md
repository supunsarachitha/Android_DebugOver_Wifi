# 📡 Android Debug Over WiFi

A small Windows desktop utility for connecting to Android devices with ADB over WiFi, so you can debug without a USB cable once the device is set up.

---

## 🧰 Features

- 📱 Lists the Android devices ADB can see (serial, model and state), updating as devices connect or disconnect
- 🔌 Connects to a device by IP address with one click
- ❌ Disconnects the WiFi (`:5555`) devices again
- 💾 Remembers the last IP address you used
- 🖥️ WPF app written in C# for .NET Framework 4.7.2, using [SharpAdbClient](https://www.nuget.org/packages/SharpAdbClient/2.3.23)

---

## 🚀 Getting Started

### Requirements

- Windows with .NET Framework 4.7.2 or later
- Android SDK platform-tools (`adb.exe`) at `C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe`. This path is currently fixed in `MainWindow.xaml.cs`; change it there if your SDK lives elsewhere.
- An Android device with Developer Options and USB debugging enabled, on the same network as the PC
- A USB cable, for the first-time setup only

### Build

Open `Android_DebugOver_Wifi.sln` in Visual Studio, restore the NuGet packages and build (Debug or Release).

### Usage

1. Connect the device by USB and make it listen for ADB over TCP/IP, for example `adb tcpip 5555`. The app does not do this step for you.
2. Launch the app. The device shows up in **Devices List**.
3. Type the device's IP address in **Selected IP Address** (find it in the device's WiFi settings) and click **Connect**.
4. When you see "Operation Success", unplug the USB cable. The device now appears with an `ip:5555` serial.
5. Click **Disconnect** to drop the WiFi connection(s).

---

## 🛠️ Built With

- **C#**, **WPF**, **.NET Framework 4.7.2**
- **SharpAdbClient 2.3.23**
- **Jekyll Cayman theme** (GitHub Pages)

---

## 📄 License

This project is open-source and available under the MIT License.

---

## 👤 Author

Maintained by [Supun Sarachitha](https://github.com/supunsarachitha) — feel free to fork, contribute, or reach out!

---

## 🙌 Contributions

Pull requests are welcome!
