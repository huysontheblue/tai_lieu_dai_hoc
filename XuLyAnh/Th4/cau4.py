# Sử dụng các phương pháp tách biên cho cùng 1 ảnh, hiện các kết quả trên matplotlib
import cv2
import matplotlib.pyplot as plt

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
img_rgb = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

img1 = cv2.blur(img_rgb,(3,3))
gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
img_r = cv2.cvtColor(gray, cv2.COLOR_BGR2RGB)

Gx = cv2.Sobel(gray,cv2.CV_16S,1,0,ksize=3)
Gy = cv2.Sobel(gray,cv2.CV_16S,0,1,ksize=3)
absGx = cv2.convertScaleAbs(Gx)
absGy = cv2.convertScaleAbs(Gy)
result1 = cv2.addWeighted(absGx,3.5,absGy,0.5,0)
img_result1 = cv2.cvtColor(result1, cv2.COLOR_BGR2RGB)

img2 = cv2.Laplacian(gray,cv2.CV_64F,ksize=3)
result2 = cv2.convertScaleAbs(img2)
img_result2 = cv2.cvtColor(result2, cv2.COLOR_BGR2RGB)

gray = cv2.cvtColor(img1,cv2.COLOR_BGR2GRAY)
result3 = cv2.Canny(gray,100,200)
img_result3 = cv2.cvtColor(result3, cv2.COLOR_BGR2RGB)

plt.subplot(2,2,1).axis('off')
plt.title("ảnh gốc")
plt1 = plt.imshow(img_r)

plt.subplot(2,2,2).axis('off')
plt.title("Tách biên Sobel")
plt2 = plt.imshow(img_result1)

plt.subplot(2,2,3).axis('off')
plt.title("Tách biên Laplace")
plt3 = plt.imshow(img_result2)

plt.subplot(2,2,4).axis('off')
plt.title("Tách biên Canny")
plt4 = plt.imshow(img_result3)

cv2.waitKey(0)
cv2.destroyAllWindows()