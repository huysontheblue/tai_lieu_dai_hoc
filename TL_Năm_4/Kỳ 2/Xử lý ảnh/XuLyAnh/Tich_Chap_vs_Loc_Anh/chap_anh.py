
import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
kernel = np.ones((5,5),np.float32)/25
imgSmooth = cv2.filter2D(img,-1,kernel)

plt.subplot(121),plt.imshow(img),plt.title('Anh goc')
plt.xticks([]), plt.yticks([])
plt.subplot(122),plt.imshow(imgSmooth),plt.title('Anh sau khi tich chap')
plt.xticks([]), plt.yticks([])
plt.show()