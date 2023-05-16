import cv2
import numpy as np
import matplotlib.pyplot as plt
# đọc ảnh
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")     

# ảnh sau khi cắt
# Cropping an image
anhcat = img[80:280, 150:330]

# đổi ảnh vừa cắt sang hệ màu RGB
anhrgb = cv2.cvtColor(anhcat, cv2.COLOR_BGR2RGB)

# phân ngưỡng bằng thuật toán otsu
anhxam = cv2.cvtColor(anhcat, cv2.COLOR_BGR2GRAY)
retval, threshold = cv2.threshold(anhxam, 12, 255, cv2.THRESH_BINARY)

# Tách biên ảnh bằng phương pháp Canny
locanh = cv2.GaussianBlur(anhcat,(5,5),0)
anhxam = cv2.cvtColor(locanh, cv2.COLOR_BGR2GRAY)
anhcanny = cv2.Canny(anhxam,100,200)
anhmau3 = cv2.cvtColor(anhcanny, cv2.COLOR_BGR2RGB)

#Hiển thị ảnh trên matplotlib 
plt.subplot(2,2,1).axis('off'),plt.imshow(anhcat),plt.title('Ảnh sau khi cắt')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhrgb),plt.title('Ảnh âm bản')
plt.subplot(2,2,3).axis('off'),plt.imshow(threshold),plt.title('Ảnh phân ngưỡng')
plt.subplot(2,2,4).axis('off'),plt.imshow(anhmau3),plt.title('Tách biên Canny')

cv2.waitKey(0)
cv2.destroyAllWindows()