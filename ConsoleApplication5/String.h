#pragma once
#include <string>

class String {
private:
    std::string value;

public:
    String(const std::string& val);
    std::string getValue() const;
    void setValue(const std::string& val);
    static std::string getDefaultString();
};

