import cv2

# tải tệp xml 
face = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')

# Để quay video từ webcam.
cap = cv2.VideoCapture(0)

# Sử dụng tệp video làm đầu vào
# cap = cv2.VideoCapture('filename.mp4')

while True:
    # Đọc khung
    _, img = cap.read()

    # Chuyển đổi sang thang độ xám
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # gray: là nguồn/bức ảnh xám.
    # scaleFactor: độ scale sau mỗi lần quét, tính theo 0.01 = 1%. Nếu như để scaleFactor = 1 thì tấm ảnh sẽ giữ nguyên
    # minNeighbors: scale và quét ảnh cho đến khi không thể scale được nữa thì lúc này sẽ xuất 
    # hiện những khung ảnh trùng nhau, số lần trùng nhau chính là tham số minNeighbors để quyết 
    # định cho việc có chọn khung ảnh này là khuôn mặt hay không.
    
    # faces = faceCascade.detectMultiScale(gray,scaleFactor = 1.1,minNeighbors = 5)
    # Phát hiện khuôn mặt
    faces = face.detectMultiScale(gray, 1.1, 4)

    # Vẽ hình chữ nhật xung quanh mỗi mặt
    for (x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 3)

    # Hiển thị
    cv2.imshow('img', img)

    # thoát
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
    
# Giải phóng đối tượng VideoCapture
cap.release()
cv2.destroyAllWindows()