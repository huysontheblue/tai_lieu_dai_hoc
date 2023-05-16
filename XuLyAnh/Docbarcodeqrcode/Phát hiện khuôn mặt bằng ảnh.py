import cv2

# Bước 1: Tấm ảnh và tệp tin xml
face_cascade = cv2.CascadeClassifier("haarcascade_frontalface_default.xml")
image = cv2.imread("D:\\XuLyAnh\\anhson1.jpg")

# Bước 2: Tạo một bức ảnh xám
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# Bước 3: Tìm khuôn mặt
faces = face_cascade.detectMultiScale(gray,scaleFactor = 1.1,minNeighbors = 5,)

# Bước 4: Vẽ các khuôn mặt đã nhận diện được lên tấm ảnh gốc
for (x, y, w, h) in faces:
    cv2.rectangle(image, (x, y), (x+w, y+h), (0, 255, 0), 2)

# Bước 5: Hiển thị và vẽ lên màn hình
cv2.imshow("Phat hiẹn khuon mat", image)

cv2.waitKey(0)
cv2.destroyAllWindows()
