import cv2

img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
img1 = cv2.blur(img,(3,3))
gray = cv2.cvtColor(img1,cv2.COLOR_BGR2GRAY)
    
result = cv2.Canny(gray,100,200)
cv2.imshow( 'Anh gov',img)
cv2.imshow('Anh tach bien',result)
#cv2.imwrite("anh_canny.jpg",result)
cv2.waitKey(0)
cv2.destroyAllWindows()
