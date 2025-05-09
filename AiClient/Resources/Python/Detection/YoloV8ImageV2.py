import sys
import cv2
import json
import numpy as np
from ultralytics import YOLO

# Load YOLO model once (instead of restarting per frame)
model_path = sys.argv[1]
model = YOLO(model_path).to("cuda")  # 🔹 Use GPU for speed

buffer = b""  # Temporary storage

while True:
    chunk = sys.stdin.buffer.read(4096)  # Read in chunks
    if not chunk:
        break

    buffer += chunk

    if b"\nEND\n" in buffer:
        frame_data, buffer = buffer.split(b"\nEND\n", 1)  # Extract frame

        # 🔹 Find metadata (first JSON line)
        split_idx = frame_data.find(b"\n")  # 🔹 Metadata ends at the first newline
        if split_idx == -1:
            continue  # Ignore if there's no metadata
        
        frame_metadata = frame_data[:split_idx].decode("utf-8")  # Extract JSON
        image_bytes = frame_data[split_idx+1:]  # Extract image bytes

        # 🔹 Convert metadata JSON to Python object
        import json
        frame_info = json.loads(frame_metadata)
        frame_id = frame_info["frame_id"]  # Extract frame ID

        # Convert bytes to NumPy array and decode image
        nparr = np.frombuffer(image_bytes, np.uint8)
        image = cv2.imdecode(nparr, cv2.IMREAD_COLOR)

        # Run YOLO detection
        #results = model.predict(image, imgsz=320, max_det=15, verbose=False)
        results = model.predict(image, max_det=15, verbose=False, half=True)


        # Convert results to JSON with frame ID
        detections = {
            "frameid": frame_id,  # 🔹 Include correct frame ID
            "objects": [
                {
                    "class": results[0].names[box.cls[0].item()],
                    "confidence": float(box.conf[0].item()),
                    "box": box.xywh[0].tolist()
                }
                for box in results[0].boxes
            ]
        }
        # 🔹 Print JSON output with frame ID
        print(json.dumps(detections))
        sys.stdout.flush()

