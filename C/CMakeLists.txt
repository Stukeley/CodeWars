cmake_minimum_required(VERSION 3.13)
project(C)
set(CMAKE_CXX_STANDARD 17)

set(SOURCE_FILES Main.c)
#set(SOURCE_FILES src/SumsOfPerfectSquares.c)

add_executable(C ${SOURCE_FILES})