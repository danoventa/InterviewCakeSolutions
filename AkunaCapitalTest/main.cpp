#include <iostream>
#include <altivec.h>
#include <vector>

int main() {

    std::vector<std::vector<int>> arr {{3, 3, 3}, {3, 3, 3}, {3, 3, 3}, {3, 3, 3}};

    std::cout << "ROWS: " << arr.size() << std::endl;

    return 0;

}
