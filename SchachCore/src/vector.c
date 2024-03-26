#include "pch.h"
#include "vector.h"

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
