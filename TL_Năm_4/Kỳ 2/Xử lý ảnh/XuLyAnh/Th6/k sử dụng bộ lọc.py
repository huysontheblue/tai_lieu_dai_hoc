# 1. Phân đoạn ảnh dựa vào phân ngưỡng. 
# - Áp dụng các thuật toán phân ngưỡng nhị phân, phân ngưỡng thích nghi, phân ngưỡng otsu (có sử dụng lọc và không sử dụng bộ lọc).
# - Hiện các ảnh trên matplotlib k sử dụng bộ lọc

import cv2
import matplotlib.pyplot as plt

# lấy ảnh
img = cv2.imread("D:\\XuLyAnh\\hoahong.png")
anhmau0 = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
# chuyển ảnh xám
anhxam = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# Phân ngưỡng ảnh bằng thuật toán phân ngưỡng nhị phân 
ret, thresh1 = cv2.threshold(anhxam,128,255,cv2.THRESH_BINARY)
anhmau1 = cv2.cvtColor(thresh1, cv2.COLOR_BGR2RGB)

# phân ngưỡng thích nghi 
thichnghi = cv2.adaptiveThreshold(anhxam, 255, cv2.ADAPTIVE_THRESH_MEAN_C,cv2.THRESH_BINARY,55,0 )
anhmau2 = cv2.cvtColor(thichnghi, cv2.COLOR_BGR2RGB)

# phân ngưỡng bằng thuật toán otsu
retval, threshold = cv2.threshold(anhxam, 50, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
#anhmau3 = cv2.cvtColor(threshold, cv2.COLOR_BGR2RGB)

# in ra bằng matlotlib
plt.subplot(2,2,1).axis('off'),plt.imshow(anhmau0),plt.title('Ảnh ban đầu')
plt.subplot(2,2,2).axis('off'),plt.imshow(anhmau1),plt.title('Ảnh phân ngưỡng nhị phân')
plt.subplot(2,2,3).axis('off'),plt.imshow(anhmau2),plt.title('Ảnh phân ngưỡng thích nghi')
plt.subplot(2,2,4).axis('off'),plt.imshow(threshold),plt.title('Ảnh phân ngưỡng Otsu')


cv2.waitKey()
cv2.destroyAllWindows()