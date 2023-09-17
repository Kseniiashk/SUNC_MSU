import numpy as np

def prod_non_zero_diag_vect(x):
    a = np.diag(x)
    return a[np.nonzero(a)].prod()

def are_multisets_equal_vect(x, y):
    return np.array_equal(np.sort(np.unique(x)), np.sort(np.unique(y)))

def max_after_zero_vect(x):
    a = np.where(x[:-1] == 0)[0]
    return np.max(x[a + 1])

def convert_image_vect(img, coeff):
    return np.sum(img * coeff, axis = -1)

def run_length_encoding_vect(x):
    y = np.hstack((np.array(((x[0] + 1) % 2)), x[:- 1]))
    res = np.hstack((np.arange(np.size(x))[x != y][1:], np.array([np.size(x)]))) - np.arange(np.size(x))[x != y]
    return x[x != y], res

def pairwise_distance_vect(x, y):
    return np.sqrt(np.sum((x[:, np.newaxis] - y) ** 2, axis = -1))
