
import cv2

def trackChaned(x):
  pass
 
cv2.namedWindow('Trackbar nhi phan')
hh='Max'
hl='Min'
wnd = 'Colorbars'
cv2.createTrackbar("Max", "Trackbar nhi phan",0,255,trackChaned)
cv2.createTrackbar("Min", "Trackbar nhi phan",0,255,trackChaned)
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)
img = cv2.resize(img, (0,0), fx=0.5, fy=0.5)
 
while(True):
   hul=cv2.getTrackbarPos("Max", "Trackbar nhi phan")
   huh=cv2.getTrackbarPos("Min", "Trackbar nhi phan")   
   ret,thresh4 = cv2.threshold(img,hul,huh,cv2.THRESH_TOZERO) 
   cv2.imshow("Anh son",thresh4)
   if cv2.waitKey(1) == ord('q'):
       break
cv2.destroyAllWindows()

