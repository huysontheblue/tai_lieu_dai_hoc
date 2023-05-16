# 2. Đọc ảnh và thực hiện phép biến đổi phối cảnh cho ảnh

import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
anhmau1 = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
pts1 = np.float32([[50,50],[350,50],[50,350],[350,350]])
pts2 = np.float32([[0,0],[200,50],[50,300],[300,300]])

M = cv2.getPerspectiveTransform(pts1,pts2)

dst = cv2.warpPerspective(anhmau1,M,(300,300))

plt.subplot(121).axis('off'),plt.imshow(anhmau1),plt.title('Ảnh đầu vào')
for (x, y) in pts1:
  plt.scatter(x, y, s=50, c='white', marker='x')
plt.subplot(122).axis('off'),plt.imshow(dst),plt.title('Sau khi biến đổi phối cảnh')
for (x, y) in pts2:
  plt.scatter(x, y, s=50, c='white', marker='x')
plt.show()
