#time to run and return to AiClient is roughly 2 seconds.  too slow.
import sys
import cv2
import json
import numpy as np
import torch
from ultralytics import YOLO

print("CUDA Available:", torch.cuda.is_available())


image_bytes = sys.stdin.buffer.read()
nparr = np.frombuffer(image_bytes, np.uint8)
image = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
image = cv2.resize(image, (320, 320)) 
model_path = sys.argv[1]

# Run YOLOv8
model = YOLO(model_path).to('cuda')
#results = model.predict(image, verbose=False)
results = model.predict(image, imgsz=320)


# Convert results to JSON
detections = []
for box in results[0].boxes:  # Access YOLOv8 detection boxes
    detections.append({
        "class": results[0].names[box.cls[0].item()],  # Get class name
        "confidence": float(box.conf[0].item()),  # Get confidence
        "box": box.xywh[0].tolist()  # Convert bounding box to list
    })

print(json.dumps(detections))
sys.stdout.flush()
