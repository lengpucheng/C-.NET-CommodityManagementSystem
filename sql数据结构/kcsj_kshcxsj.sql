/*
 Navicat Premium Data Transfer

 Source Server         : 可视化程序设计
 Source Server Type    : MySQL
 Source Server Version : 80016
 Source Host           : sql.hll520.cn:3306
 Source Schema         : kcsj_kshcxsj

 Target Server Type    : MySQL
 Target Server Version : 80016
 File Encoding         : 65001

 Date: 12/05/2020 14:24:20
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for commodity
-- ----------------------------
DROP TABLE IF EXISTS `commodity`;
CREATE TABLE `commodity`  (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `Barcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '条码',
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '名称',
  `factory` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '厂家',
  `category` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '类别',
  `price` decimal(10, 2) NOT NULL DEFAULT 0.00 COMMENT '价格',
  `sales` int(10) NOT NULL DEFAULT 0 COMMENT '销量',
  `sum` int(10) NOT NULL DEFAULT 0 COMMENT '库存',
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `code`(`Barcode`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1022512115 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of commodity
-- ----------------------------
INSERT INTO `commodity` VALUES (10011, '17042782', '老乌龟', '乌龟一场', '动物', 29.89, 0, 500);
INSERT INTO `commodity` VALUES (1022512116, '17042799', '小乌龟', '乌龟一厂', '动物', 19.90, 0, 100);
INSERT INTO `commodity` VALUES (1022512117, '10099', '王八', '乌龟一厂', '动物', 45.78, 0, 20);
INSERT INTO `commodity` VALUES (1022512118, '10088', '可视化程序设计', '纺大老夏', '书籍', 19.90, 45, 455);
INSERT INTO `commodity` VALUES (1022512119, '11232', '移动平台程序设计', '纺大小苏', '书籍', 20.99, 0, 400);
INSERT INTO `commodity` VALUES (1022512120, '14522', 'KFC优惠价', 'KFC', '电子卡', 49.99, 16, 184);
INSERT INTO `commodity` VALUES (1022512121, '10086', '电话充值卡', '中国移动', '电子卡', 49.99, 72, 328);
INSERT INTO `commodity` VALUES (1022512122, '10022', 'WTUCloud存储卡', '冷朴承', '电子卡', 99.89, 14, -4);

-- ----------------------------
-- Table structure for sales
-- ----------------------------
DROP TABLE IF EXISTS `sales`;
CREATE TABLE `sales`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `val` varchar(999) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '货物清单',
  `amount` decimal(10, 0) NOT NULL DEFAULT 0 COMMENT '金额',
  `user_id` int(11) NULL DEFAULT NULL COMMENT '操作人员id',
  `user` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '操作人员',
  `time` timestamp(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0) COMMENT '时间',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sales
-- ----------------------------
INSERT INTO `sales` VALUES (28, '电话充值卡*5|', 250, 10002, '冷朴承', '2020-05-12 13:32:20');
INSERT INTO `sales` VALUES (29, '可视化程序设计*15|移动平台程序设计*24|王八*20|', 1718, 10002, '冷朴承', '2020-05-12 13:58:52');
INSERT INTO `sales` VALUES (30, '电话充值卡*50|', 2500, 10002, '冷朴承', '2020-05-12 13:59:04');
INSERT INTO `sales` VALUES (31, 'WTUCloud存储卡*2|', 200, 10002, '冷朴承', '2020-05-12 13:59:20');
INSERT INTO `sales` VALUES (32, 'WTUCloud存储卡*1|WTUCloud存储卡*1|WTUCloud存储卡*1|WTUCloud存储卡*1|', 400, 10002, '冷朴承', '2020-05-12 13:59:32');
INSERT INTO `sales` VALUES (33, 'WTUCloud存储卡*1|电话充值卡*1|王八*20|', 1065, 10001, '鲁云浩', '2020-05-12 14:04:45');
INSERT INTO `sales` VALUES (34, '电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|', 300, 10001, '鲁云浩', '2020-05-12 14:19:02');
INSERT INTO `sales` VALUES (35, '电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|', 300, 10001, '鲁云浩', '2020-05-12 14:19:05');
INSERT INTO `sales` VALUES (36, '电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|电话充值卡*1|', 250, 10001, '鲁云浩', '2020-05-12 14:19:07');
INSERT INTO `sales` VALUES (37, 'WTUCloud存储卡*1|WTUCloud存储卡*1|WTUCloud存储卡*1|WTUCloud存储卡*1|WTUCloud存储卡*1|', 499, 10001, '鲁云浩', '2020-05-12 14:19:12');
INSERT INTO `sales` VALUES (38, 'KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|', 200, 10001, '鲁云浩', '2020-05-12 14:19:24');
INSERT INTO `sales` VALUES (39, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:25');
INSERT INTO `sales` VALUES (40, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:26');
INSERT INTO `sales` VALUES (41, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:26');
INSERT INTO `sales` VALUES (42, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:27');
INSERT INTO `sales` VALUES (43, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:28');
INSERT INTO `sales` VALUES (44, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:28');
INSERT INTO `sales` VALUES (45, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:28');
INSERT INTO `sales` VALUES (46, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:28');
INSERT INTO `sales` VALUES (47, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:28');
INSERT INTO `sales` VALUES (48, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:29');
INSERT INTO `sales` VALUES (49, 'KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|', 250, 10001, '鲁云浩', '2020-05-12 14:19:31');
INSERT INTO `sales` VALUES (50, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:33');
INSERT INTO `sales` VALUES (51, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:33');
INSERT INTO `sales` VALUES (52, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:34');
INSERT INTO `sales` VALUES (53, 'KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|KFC优惠价*1|', 350, 10001, '鲁云浩', '2020-05-12 14:19:37');
INSERT INTO `sales` VALUES (54, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:38');
INSERT INTO `sales` VALUES (55, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:39');
INSERT INTO `sales` VALUES (56, '', 0, 10001, '鲁云浩', '2020-05-12 14:19:39');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `_id` int(5) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uname` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `role` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '用户',
  `Sales` decimal(10, 0) NOT NULL DEFAULT 0,
  PRIMARY KEY (`_id`) USING BTREE,
  UNIQUE INDEX `name`(`uname`) USING BTREE COMMENT '不能重复'
) ENGINE = InnoDB AUTO_INCREMENT = 10002 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (10001, '鲁云浩', 'lyh', 'lyh', '用户', 8563);
INSERT INTO `user` VALUES (10002, '冷朴承', 'lpc', 'lpc2020', '管理员', 5068);
INSERT INTO `user` VALUES (10011, 'dome', 'dome', 'dome1', '用户', 0);
INSERT INTO `user` VALUES (10012, 'admin', 'admin', 'admin', '管理员', 0);

-- ----------------------------
-- Triggers structure for table sales
-- ----------------------------
DROP TRIGGER IF EXISTS `up_sales`;
delimiter ;;
CREATE TRIGGER `up_sales` AFTER INSERT ON `sales` FOR EACH ROW BEGIN
UPDATE user SET user.Sales=user.Sales+new.amount WHERE user._id=new.user_id;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
