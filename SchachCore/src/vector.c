#include "pch.h"
#include "vector.h"

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

errno_t reallocate_memcpy_vector(Vector* vector, size_t required_capacity, void* sample)
 {
     void* mem = malloc(required_capacity * vector->colct_size);
     if (!mem) return ENOMEM;

     size_t min = MIN(required_capacity, vector->capacity);

     memcpy(mem, vector->collections, min* vector->colct_size);

     if (min != required_capacity) {
         void* mem_void_starts = (char*)mem + (min * vector->colct_size);
         size_t diff = required_capacity - min;

         if (sample)
             memset(mem_void_starts, 0, diff);
         else
             set_sampled_memcpy(mem_void_starts, vector->colct_size, diff, sample);
     }

     free(vector->collections);
     vector->collections = mem;
     vector->capacity = required_capacity;

     if (vector->size > vector->capacity)
         vector->size = vector->capacity;

     return 0;
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

errno_t erase_element_vector(Vector* vector, size_t index) {
    if (index >= vector->size)
        return EOVERFLOW;

    for (size_t i = index; i < vector->size; i++) {
        memcpy(((char*)vector->collections) + (i - 1) * vector->colct_size, ((char*)vector->collections) + i * vector->colct_size, vector->colct_size);
    }

    return 0;
}
