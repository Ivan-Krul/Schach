#pragma once
#include <stdint.h>
#include <malloc.h>
#include <string.h>

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

Vector set_memset_vector(size_t colct_size, size_t size, void* value) {
    Vector vec;
    vec.colct_size = colct_size;
    vec.size = size;
    vec.capacity = size;

    size_t sizbyt = vec.size * vec.colct_size;
    vec.collections = malloc(sizbyt);

    colct_size = 0;

    for (size_t i = 0; i < sizbyt; i++) {
        if (colct_size == vec.colct_size)
            colct_size = 0;

        ((char*)(vec.collections))[i] = ((char*)(value))[colct_size];

        colct_size++;
    }

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



