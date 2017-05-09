cmake_minimum_required(VERSION 3.7)
project(InterviewCakeInCPP)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp HiCal.cpp HiCal.h)
add_executable(InterviewCakeInCPP ${SOURCE_FILES})