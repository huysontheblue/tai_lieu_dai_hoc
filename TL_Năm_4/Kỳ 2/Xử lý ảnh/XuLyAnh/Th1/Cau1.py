# Đoc và hiển thị ảnh
import cv2
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")          
# hiển thị ảnh
print(img[1,2])
cv2.imshow('Hien anh', img)
cv2.waitKey(5000)
cv2.destroyAllWindows()