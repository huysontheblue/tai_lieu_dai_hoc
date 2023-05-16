import cv2 as cv
import numpy as np
from matplotlib import pyplot as plt

# Tải và lọc hình ảnh
img = cv.imread("D:\\XuLyAnh\\hoahong.png")
img2 = cv.imread("D:\\XuLyAnh\\hoahong2.png")
blur = cv.GaussianBlur(img,(5,5),0)
blur2 = cv.GaussianBlur(img2,(5,5),0)

# Chuyển đổi màu từ bgr (OpenCV mặc định) sang rgb
img_rgb = cv.cvtColor(img, cv.COLOR_BGR2RGB)
blur_rgb = cv.cvtColor(blur, cv.COLOR_BGR2RGB)
img_rgb2 = cv.cvtColor(img2, cv.COLOR_BGR2RGB)
blur_rgb2 = cv.cvtColor(blur2, cv.COLOR_BGR2RGB)

plt.subplot(221),plt.imshow(img_rgb),plt.title('Anh 1')
plt.xticks([]), plt.yticks([])
plt.subplot(222),plt.imshow(blur_rgb),plt.title('Anh sau khi loc 1')
plt.xticks([]), plt.yticks([])
plt.subplot(223),plt.imshow(img_rgb2),plt.title('Anh 2')
plt.xticks([]), plt.yticks([])
plt.subplot(224),plt.imshow(blur_rgb2),plt.title('Anh sau khi loc 2')
plt.xticks([]), plt.yticks([])
plt.show()
