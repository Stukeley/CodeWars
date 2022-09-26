// Sort binary tree by levels
// https://www.codewars.com/kata/52bef5e3588c56132c0003bc
// Created by Rafał Klinowski on 24.09.2022.
//
#include <stddef.h>
#include <stdlib.h>

/* to help you solve the kata, a queue implementation has been
preloaded for you */

typedef struct Queue Queue;

// the queue elements are pointers

// creates a new queue
extern Queue *new_queue (void);
// returns the number of elements in the queue
extern size_t queue_size (const Queue *queue);
// adds an element at the back of the queue and returns the queue
extern Queue *queue_enqueue (Queue *queue, const void *data);
// removes the element at the front of the queue and returns it
extern void *queue_dequeue (Queue *queue);
// frees the queue, do not forget to call it !
extern void free_queue (Queue *queue);
/* ==================================================== */

typedef struct Tree {
	struct Tree *left, *right;
	int value;
} Tree;

int find_tree_height(Tree *tree) {
	if (tree == NULL) {
		return 0;
	}
	
	int leftHeight = find_tree_height(tree->left);
	int rightHeight = find_tree_height(tree->right);
	
	return (leftHeight > rightHeight) ? leftHeight + 1 : rightHeight + 1;
}

void enqueue_tree_level(Queue *queue, Tree *tree, int level) {
	if (tree == NULL) {
		return;
	}
	
	if (level == 0) {
		queue_enqueue(queue, &tree->value);
	}
	else {
		enqueue_tree_level(queue, tree->left, level - 1);
		enqueue_tree_level(queue, tree->right, level - 1);
	}
}

int *tree_by_levels (const Tree *tree, size_t *tree_size) {
	if (tree == NULL) {
		*tree_size = 0;
		return NULL;
	}
	else {
		Queue *queue = new_queue();

		int tree_height = find_tree_height((Tree *)tree);
		
		for (int i = 0; i < tree_height; ++i) {
			enqueue_tree_level(queue, (Tree *)tree, i);
		}
		
		*tree_size = queue_size(queue);
		
		int* result = (int*)calloc(*tree_size, sizeof(int));

		for (size_t i = 0; i < *tree_size; ++i) {
			result[i] = *(int*)queue_dequeue(queue);
		}

		free_queue(queue);
		return result;
	}
}