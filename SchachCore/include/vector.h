#pragma once
#include <stdint.h>
#include <malloc.h>
#include <string.h>

#include "min_max.h"

struct Vector {
    size_t size;
    size_t capacity;
    void* collections;

    size_t colct_size;
};
typedef struct Vector Vector;

void set_sampled_memcpy(void* mem, size_t colct_size, size_t count, void* sample);
errno_t reallocate_memcpy_vector(Vector* vector, size_t required_capacity, void* sample);
errno_t push_vector(Vector* vector, void* value);
errno_t erase_element_vector(Vector* vector, size_t index);

inline Vector set_vector(size_t colct_size) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = 0;
    vec.capacity = 0;
    return vec;
}

inline Vector set_memset_vector(size_t colct_size, size_t size, void* sample) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = size;
    vec.capacity = size;
    vec.collections = malloc(vec.size * vec.colct_size);

    set_sampled_memcpy(vec.collections, vec.colct_size, vec.size, sample);

    return vec;
}

inline Vector set_memcpy_vector(size_t colct_size, size_t size, void* ptr) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = size;
    vec.capacity = size;

    memcpy(vec.collections, ptr, colct_size * size);

    return vec;
}

inline errno_t reallocate_vector(Vector* vector, size_t required_capacity) {
    return reallocate_memcpy_vector(vector, required_capacity, 0);
}

inline errno_t resize_vector(Vector* vector, size_t new_size) {
    vector->size = new_size;
    return reallocate_vector(vector, new_size);
}

inline void pop_vector(Vector* vector) {
    if(vector->size)
        vector->size--;
}

inline void* access_vector(Vector* vector, size_t index) {
    if (index >= vector->size)
        return NULL;

    return ((char*)vector->collections) + index * vector->colct_size;
}

inline void free_vector(Vector* vector) {
    vector->size = 0;
    vector->capacity = 0;
    vector->colct_size= 0;
    free(vector->collections);
}
