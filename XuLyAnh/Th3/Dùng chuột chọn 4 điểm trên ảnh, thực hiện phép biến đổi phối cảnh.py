import cv2
import numpy as np
circles = np.zeros((4,2), np.int32)
counter = 0
def mouse(event,x,y,flags,params):
  global counter
  if event == cv2.EVENT_LBUTTONDOWN:
      circles[counter] = x,y
      counter = counter+1
      print(circles)
      cv2.circle(im,(x,y), 3,(0,255,0),-1)
im = cv2.imread("D:\\XuLyAnh\\anhk.jpg")
cv2.namedWindow('Bandau') 
while True:
    cv2.imshow('Bandau', im)
    cv2.setMouseCallback('Bandau', mouse)
    if counter == 4:
        w, h = 250,350
        MT1 = np.float32([circles[0],circles[1],circles[2],circles[3]])
        MT2 = np.float32([[0,0],[w,0],[0,h],[w,h]])
 
    M = cv2.getPerspectiveTransform(MT1, MT2)
    output = cv2.warpPerspective(im, M, (w,h))
    cv2.imshow('Out', output)

    if cv2.waitKey(5) == ord('q'):
        break
cv2.destroyAllWindows()