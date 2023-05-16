# Biến đổi phối cảnh ảnh.
import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
pts1 = np.float32([[50,50],[350,50],[50,350],[350,350]])
pts2 = np.float32([[0,0],[200,50],[50,300],[300,300]])
#hàm chuyển về màu rgb
anhmau1 = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

M = cv2.getPerspectiveTransform(pts1,pts2)

dst = cv2.warpPerspective(img,M,(300,300))
#hàm chuyển về màu rgb
anhmau2 = cv2.cvtColor(dst, cv2.COLOR_BGR2RGB)

plt.subplot(121),plt.imshow(anhmau1),plt.title('Ảnh gốc'),plt.axis('off')
for (x, y) in pts1:
  plt.scatter(x, y, s=50, c='white', marker='x')
plt.subplot(122),plt.imshow(anhmau2),plt.title('Sau khi biến đổi phối cảnh'),plt.axis('off')
for (x, y) in pts2:
  plt.scatter(x, y, s=50, c='white', marker='x')
plt.show()


