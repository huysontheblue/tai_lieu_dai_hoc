# Đọc ảnh và thực hiện các thao tác sau:
# Cắt vùng ảnh với tọa độ góc trên trái, chiều rộng, chiều cao ảnh 
# cắt nhập từ bàn phím. Dùng ảnh này để thực hiện các phép biến đổi tiếp theo
# Lọc ảnh bằng bộ lọc Gauss
# Hiển thị ảnh cắt, ảnh lọc, histogram của từng ảnh trên matplotli

import cv2

import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\hoahong.png",0)

# cắt  1 vùng ảnh vs tọa độ đc nhập vào
x1 = int(input("Nhap x1:"))
x2 = int(input("Nhap x2:"))
y1 = int(input("Nhap y1:"))
y2 = int(input("Nhap y2:"))
anhcat = img[x1:x2, y1:y2]
# chuyển vè màu rgb
# anhmau0 = cv2.cvtColor(anhcat, cv2.COLOR_BGR2RGB)
# Lọc ảnh bằng bộ lọc Gauss
anhloc = cv2.GaussianBlur(anhcat,(5,5),0)
# chuyển về màu rgb
# anhmau1 = cv2.cvtColor(anhloc, cv2.COLOR_BGR2RGB)

#Hiển thị ảnh trên matplotlib 
plt.subplot(2,2,1).axis('off'),plt.imshow(anhcat),plt.title('Ảnh cắt')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhloc),plt.title('Ảnh sau khi lọc')
# hiện histogram
plt.subplot(2,2,3).axis('off'),plt.hist(anhcat),plt.title('Histogram của anh cắt')
plt.subplot(2,2,4).axis('off'),plt.hist(anhloc),plt.title('Histogram của anh lọc')

cv2.waitKey(0)
cv2.destroyAllWindows()



