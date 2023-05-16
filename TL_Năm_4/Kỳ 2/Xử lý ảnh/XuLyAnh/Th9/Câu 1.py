# - Đọc ảnh và thực hiện các thao tác sau:
# - Đổi ảnh vừa cắt sang ảnh GRAY
# - Phân ngưỡng ảnh bằng thuật toán phân ngưỡng thích nghi
# - Hiển thị các ảnh trên matplotlib

import cv2
import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
anhmau1 = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
# cắt  1 vùng ảnh vs tọa độ đc nhập vào
x1 = int(input("Nhap x1:"))
x2 = int(input("Nhap x2:"))
y1 = int(input("Nhap y1:"))
y2 = int(input("Nhap y2:"))
anhcat = anhmau1[x1:x2, y1:y2]

# đổi ảnh vừa cắt sang ảnh gray 
anhgray = cv2.cvtColor(anhcat, cv2.COLOR_BGR2GRAY)
anhmau2 = cv2.cvtColor(anhgray, cv2.COLOR_BGR2RGB)

# phân ngưỡng thích nghi 
thichnghi = cv2.adaptiveThreshold(anhgray, 255, cv2.ADAPTIVE_THRESH_MEAN_C,cv2.THRESH_BINARY,55,0)
anhmau3 = cv2.cvtColor(thichnghi, cv2.COLOR_BGR2RGB)

#Hiển thị ảnh trên matplotlib 
plt.subplot(2,2,1).axis('off'),plt.imshow(anhmau1),plt.title('Ảnh gốc')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhcat),plt.title('Ảnh Sau khi cắt')
plt.subplot(2,2,3).axis('off'),plt.imshow(anhmau2),plt.title('Ảnh Gray')
plt.subplot(2,2,4).axis('off'),plt.imshow(anhmau3),plt.title('Ảnh phân ngưỡng thích nghi')

cv2.waitKey(0)
cv2.destroyAllWindows()