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


Vector set_vector(size_t colct_size) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = 0;
    vec.capacity = 0;
    return vec;
}

void set_sampled_memcpy(void* mem, size_t colct_size, size_t count, void* sample) {
    size_t sizbyt = count * colct_size;
    size_t colct = 0;

    for (size_t i = 0; i < sizbyt; i++) {
        if (colct == colct_size)
            colct = 0;

        ((char*)(mem))[i] = ((char*)(sample))[colct];

        colct++;
    }
}

Vector set_memset_vector(size_t colct_size, size_t size, void* sample) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = size;
    vec.capacity = size;
    vec.collections = malloc(vec.size * vec.colct_size);

    set_sampled_memcpy(vec.collections, vec.colct_size, vec.size, sample);

    return vec;
}

Vector set_memcpy_vector(size_t colct_size, size_t size, void* ptr) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = size;
    vec.capacity = size;

    memcpy(vec.collections, ptr, colct_size * size);

    return vec;
}

errno_t reallocate_memcpy_vector(Vector* vector, size_t required_capacity, void* sample);

errno_t reallocate_vector(Vector* vector, size_t required_capacity) {
    return reallocate_memcpy_vector(vector, required_capacity, 0);
}

errno_t resize_vector(Vector* vector, size_t new_size) {
    vector->size = new_size;
    return reallocate_vector(vector, new_size);
}

errno_t push_vector(Vector* vector, void* value) {
    errno_t val = 0;

    if (vector->size + 1 > vector->capacity)
        val = reallocate_vector(vector, vector->capacity ? vector->capacity * 2 : 1);


    if (val) return val;

    memcpy(
        ((char*)vector->collections) + vector->size * vector->colct_size,
        value,
        vector->colct_size);
    vector->size++;

    return val;
}

void pop_vector(Vector* vector) {
    if(vector->size)
        vector->size--;
}

errno_t erase_element_vector(Vector* vector, size_t index) {
    if (index >= vector->size)
        return EOVERFLOW;

    for (size_t i = index; i < vector->size; i++) {
        memcpy(((char*)vector->collections) + (i - 1) * vector->colct_size, ((char*)vector->collections) + i * vector->colct_size, vector->colct_size);
    }

    return 0;
}

