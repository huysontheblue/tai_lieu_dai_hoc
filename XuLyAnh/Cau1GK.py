import cv2
import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")          

# Thay đổi kích thước ảnh với hệ số tỉ lệ trục x và trục y nhập vào từ bàn phím. 
# Dùng ảnh này để thực 
x = int(input('Nhap x : '))
y = int(input('Nhap y : '))
anhmau = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
resized_img = cv2.resize(anhmau, (x, y))

# Biến đổi ảnh vừa cắt thành ảnh âm bản
amban = 255 - resized_img
anhmau1 = cv2.cvtColor(amban, cv2.COLOR_BGR2RGB)

# Phân ngưỡng ảnh bằng thuật toán phân ngưỡng nhị phân với ngưỡng nhập vào từ bàn phím
anhxam = cv2.cvtColor(resized_img, cv2.COLOR_BGR2GRAY)
z = int(input('Nhap nguong z  : '))
ret,thresh1 = cv2.threshold(anhxam,z,255,cv2.THRESH_BINARY)
anhmau2 = cv2.cvtColor(thresh1, cv2.COLOR_BGR2RGB)

# Tách biên ảnh bằng phương pháp Canny
locanh = cv2.blur(resized_img,(3,3))
anhxam = cv2.cvtColor(locanh, cv2.COLOR_BGR2GRAY)
anhcanny = cv2.Canny(anhxam,100,200)
anhmau3 = cv2.cvtColor(anhcanny, cv2.COLOR_BGR2RGB)

# in ra bằng matlotlib
plt.subplot(2,2,1).axis('off'),plt.imshow(resized_img),plt.title('Ảnh sau khi đổi kích thước')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhmau1),plt.title('Ảnh âm bản')
plt.subplot(2,2,3).axis('off'),plt.imshow(anhmau2),plt.title('Ảnh phân ngưỡng')
plt.subplot(2,2,4).axis('off'),plt.imshow(anhmau3),plt.title('Tách biên Canny')

cv2.waitKey(0)
cv2.destroyAllWindows()

