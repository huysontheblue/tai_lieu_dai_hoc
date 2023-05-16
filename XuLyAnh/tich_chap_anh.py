import numpy as np

import cv2

import matplotlib.pyplot as plt

im = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")

im = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)

im = cv2.resize(im, (100,100))

#im.shape(100, 100)

plt.figure()

plt.imshow(im, cmap='gray')

kernel = np.array([

    [1/16, 1/8, 1/16],
+
    [1/8 , 1/4, 1/8],

    [1/16, 1/8, 1/16],

]) # Gaussian Blur



kernel = np.array([

    [1, 0, -1],

    [1, 0, -1],

    [1, 0, -1],

]) # Vertical Edge



kernel = np.array([

    [-1, -1, -1],

    [-1,  8, -1],

    [-1, -1, -1],

]) # Outline

# N - f + 1

convolved_image = np.zeros((im.shape[0] - kernel.shape[0] + 1, im.shape[1] - kernel.shape[1] + 1))

convolved_image.shape

(98, 98)



for i in range(convolved_image.shape[0]):

    for j in range(convolved_image.shape[1]):

        patch = im[i:i+kernel.shape[0], j:j+kernel.shape[1]]

        hprod = (patch * kernel).sum()

        convolved_image[i,j] = hprod



plt.figure()
plt.axis('off')
plt.imshow(convolved_image, cmap='gray')