# Project Setup

## Installation Instructions

1. Install the core Emgu CV package:
2. Install the Emgu CV UI package:
3. Install the Emgu CV runtime for Windows (version 4.10.0.5680):

## 📷 Webcam Capture Note
To capture live images from a webcam, Device.cs and DeviceManager.cs are required. However, these components only support VFW (Video for Windows), which is not compatible with my webcam.

As a result, I’ve opted to use the Emgu CV library instead, which leverages DirectShow or Media Foundation—both of which offer broader support for modern webcams.

## 🔧 Future Support Suggestion:
It would be beneficial to update or extend Device.cs and DeviceManager.cs to support DirectShow, enabling compatibility with a wider range of webcam devices.

## Author

**Lemuel Jay**
