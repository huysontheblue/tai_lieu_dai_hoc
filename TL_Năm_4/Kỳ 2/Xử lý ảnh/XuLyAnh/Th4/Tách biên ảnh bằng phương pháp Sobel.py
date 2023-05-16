import cv2

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
img1 = cv2.blur(img,(3,3))
gray = cv2.cvtColor(img1,cv2.COLOR_BGR2GRAY)
    
Gx = cv2.Sobel(gray,cv2.CV_16S,1,0,ksize=3)
Gy = cv2.Sobel(gray,cv2.CV_16S,0,1,ksize=3)
absGx = cv2.convertScaleAbs(Gx)
absGy = cv2. convertScaleAbs(Gy)
result = cv2.addWeighted(absGx,3.5, absGy,0.5,0) 
cv2.imshow( 'Anh goc',img)
cv2.imshow( 'Anh tach bien',result)
cv2.imwrite("anh_sobel.jpg",result)
cv2.waitKey(0)
cv2.destroyAllWindows()
