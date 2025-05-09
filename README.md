# Pool Ball Detection AI .Net

My goal is to make this as generic as possible so it can handle any type of AI interations, whether it be images, files, or even a small chatbot.

This is a work in progress and is the result of 9 hours of work, be kind.
My video card is ancient, but still gives me 8 fps with this software.

My Hardware:
	Video Card - GTX 1050ti 4G Air Cooled
	CPU - Intel I5 14600 Air Cooled
	Ram - 32gb
	

These are the steps I took to setup my environemnt.  

Environment Setup
1. Install CUDA (need ll.8 for GTX 1050 ti)
	- see if its installed
		- nvcc --version
	- install it if needed.
		- https://developer.nvidia.com/cuda-11-8-0-download-archive
2. Install Python
	- https://www.python.org/downloads/
3. Install PIP
	- python -m pip --version
	- python -m ensurepip --default-pip
	- python -m pip install --upgrade pip
	- pip --version
4. Install torch, ect.. FOR CUDA 11.8 <-- My version because my video card to so old.
	- pip uninstall torch torchvision torchaudio
	- pip install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu118
5. Install torch, ect.. FOR CUDA 12.9
	- pip uninstall torch torchvision torchaudio
	- pip install torch torchvision torchaudio --index-url  https://download.pytorch.org/whl/cu121
6. Install YOLO
	- pip install ultralytics
7. Configure Environment Variables for python and pip.
8. RESTART PC
9. Check CUDA Compatibility
	- nvcc --version	
10. Check for CUDA Installation Python
'''
	import torch
	print(torch.cuda.is_available())  # Should return True
	print(torch.cuda.get_device_name(0))  # Should display your video card, mine displayed as GTX 1050 Ti
'''