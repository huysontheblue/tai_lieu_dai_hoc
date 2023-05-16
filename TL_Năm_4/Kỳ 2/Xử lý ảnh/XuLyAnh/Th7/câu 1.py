# 1. Đọc ảnh và thực hiện các thao tác sau:
# - Cắt 1 vùng ảnh với tọa độ góc trên trái, dưới phải được nhập vào
# - Đổi ảnh vừa cắt sang ảnh GRAY
# - Phân ngưỡng ảnh bằng thuật toán phân ngưỡng thích nghi
# - Tách biên ảnh bằng phương pháp Canny
# - Hiển thị ảnh gốc, ảnh đổi hệ màu, ảnh phân ngưỡng, ảnh 
# tách biên trên matplotlib

import cv2
import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")     

# cắt  1 vùng ảnh vs tọa độ đc nhập vào
x1 = int(input("Nhap x1:"))
x2 = int(input("Nhap x2:"))
y1 = int(input("Nhap y1:"))
y2 = int(input("Nhap y2:"))
anhcat = img[x1:x2, y1:y2]
anhmau0 = cv2.cvtColor(anhcat, cv2.COLOR_BGR2RGB)

# đổi ảnh vừa cắt sang ảnh gray 
anhgray = cv2.cvtColor(anhcat, cv2.COLOR_BGR2GRAY)
anhmau1 = cv2.cvtColor(anhgray, cv2.COLOR_BGR2RGB)

# phân ngưỡng thích nghi 
thichnghi = cv2.adaptiveThreshold(anhgray, 255, cv2.ADAPTIVE_THRESH_MEAN_C,cv2.THRESH_BINARY,55,0 )
anhmau2 = cv2.cvtColor(thichnghi, cv2.COLOR_BGR2RGB)

# Tách biên ảnh bằng phương pháp Canny
locanh = cv2.GaussianBlur(anhcat,(5,5),0)
anhxam = cv2.cvtColor(locanh, cv2.COLOR_BGR2GRAY)
anhcanny = cv2.Canny(anhxam,100,200)
anhmau3 = cv2.cvtColor(anhcanny, cv2.COLOR_BGR2RGB)

#Hiển thị ảnh trên matplotlib 
plt.subplot(2,2,1).axis('off'),plt.imshow(anhmau0),plt.title('Ảnh cắt')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhmau1),plt.title('Ảnh Gray(ảnh xám)')
plt.subplot(2,2,3).axis('off'),plt.imshow(anhmau2),plt.title('Ảnh phân ngưỡng thích nghi')
plt.subplot(2,2,4).axis('off'),plt.imshow(anhmau3),plt.title('Tách biên Canny')

cv2.waitKey(0)
cv2.destroyAllWindows()