var _moveX = keyboard_check(vk_right) - keyboard_check(vk_left);
var _moveY = keyboard_check(vk_down) - keyboard_check(vk_up);

hsp = moveSpeed * _moveX;
vsp = moveSpeed * _moveY;

x += hsp;
y += vsp;