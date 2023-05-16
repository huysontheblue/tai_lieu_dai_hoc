# import numpy as np
# import matplotlib.pyplot as plt
# from sklearn import neighbors, datasets
# from sklearn.model_selection import train_test_split

# iris = datasets.load_iris()
# iris_X = iris.data
# iris_y = iris.target
# # print ('Number of classes: %d' %len(np.unique(iris_y))
# # print 'Number of data points: %d' %len(iris_y)


# X_train, X_test, y_train, y_test = train_test_split(
#      iris_X, iris_y, test_size=50)

# print ("Training size: %d" %len(y_train))
# print ("Test size    : %d" %len(y_test))


# clf = neighbors.KNeighborsClassifier(n_neighbors = 1, p = 2)
# clf.fit(X_train, y_train)
# y_pred = clf.predict(X_test)

# print ("Print results for 20 test data points:")
# print ("Predicted labels: ", y_pred[20:40])
# print ("Ground truth    : ", y_test[20:40])



# Importing the dataset
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.neighbors import KNeighborsClassifier
from sklearn import neighbors, datasets

iris = datasets.load_iris()
X, Y = iris.data, iris.target

# Training the K-NN model on the Training set
KNN_Classifier = neighbors.KNeighborsClassifier(n_neighbors=1, p=2)
KNN_Classifier.fit(X, Y)

# Predicting the Test set results
y_pred = KNN_Classifier.predict(X)
print(Y)
print(y_pred)

from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
ac = accuracy_score(Y, y_pred)
print(ac)

# Training the K-NN model on the Training set
KNN_Classifier = neighbors.KNeighborsClassifier(n_neighbors=3, p=2)
KNN_Classifier.fit(X, Y)

# Predicting the Test set results
y_pred = KNN_Classifier.predict(X)
print(Y)
print(y_pred)

from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
ac = accuracy_score(Y, y_pred)
print(ac)

# Training the K-NN model on the Training set
KNN_Classifier = neighbors.KNeighborsClassifier(n_neighbors=5, p=2)
KNN_Classifier.fit(X, Y)

# Predicting the Test set results
y_pred = KNN_Classifier.predict(X)
print(Y)
print(y_pred)

from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
ac = accuracy_score(Y, y_pred)
print(ac)


# err = 1 - ac
# print(err)


# # Split the data set into training and testing
# X_train, X_test, y_train, y_test = train_test_split(X, Y, test_size = 0.20, random_state=0)

# # Feature Scaling
# from sklearn.preprocessing import StandardScaler
# sc = StandardScaler()
# X_train = sc.fit_transform(X_train)
# X_test = sc.transform(X_test)

# # Training the K-NN model on the Training set
# KNeighborsClassifier(n_neighbors=1, p=2) # p=2: Khoảng cách Euclide
# KNN_Classifier.fit(X_train, y_train)

# # Predicting the Test set results
# y_pred = KNN_Classifier.predict(X_test)
# # print(y_test)


# # Evaluate the training and test score
# print('Training accuracy score: %.3f' % KNN_Classifier.score(X_train, y_train))
# print('Test accuracy score: %.3f' % KNN_Classifier.score(X_test, y_test))

# #Hoặc
# #Calculate the accuracy of the model
# print(KNN_Classifier.score(X_test, y_test))


# # # # Making the Confusion Matrix
# # from sklearn.metrics import confusion_matrix, accuracy_score, classification_report
# # cm = confusion_matrix(y_test, y_pred)
# # result1 = classification_report(y_test, y_pred)
# # ac = accuracy_score(y_test, y_pred)
# # print(cm)
# # print(result1)
