SELECT c.full_name, COUNT(o.id) AS total_orders, SUM(o.order_total) AS total_spent
FROM CUSTOMER_T2 c
LEFT JOIN ORDERS_T2 o ON c.id = o.customer_id
GROUP BY c.id;

SELECT c.full_name,
       COUNT(o.id) AS total_orders,
       (SELECT COUNT(id) FROM ORDERS_T2
        WHERE customer_id = c.id AND payment_status = 'Pending') AS unpaid_orders
FROM CUSTOMER_T2 c
JOIN ORDERS_T2 o ON c.id = o.customer_id
GROUP BY c.id, c.full_name
HAVING total_orders > 3 AND unpaid_orders >= 1;

SELECT p.name,
       COUNT(DISTINCT c.id) AS distinct_customers,
       SUM(oi.quantity) AS total_units_sold,
       SUM(oi.unit_price_at_sale * oi.quantity) AS total_revenue
FROM CUSTOMER_T2 c
JOIN ORDERS_T2 o ON o.customer_id = c.id
JOIN ORDER_ITEM_T2 oi ON o.id = oi.order_id
JOIN PRODUCT_T2 p ON p.id = oi.product_id
GROUP BY p.id
ORDER BY total_revenue DESC;

SELECT
    id AS order_id,
    payment_status,
    CASE
        WHEN payment_status = 'Pending' THEN NULL
        ELSE DATEDIFF(payment_date, order_date)
    END AS days_between_order_and_pay
FROM ORDERS_T2;

WITH product_totals AS (
    SELECT
        p.id AS product_id,
        p.name AS product_name,
        c.id AS category_id,
        c.name AS category_name,
        SUM(oi.quantity) AS total_units_sold
    FROM ORDER_ITEM_T2 oi
    JOIN PRODUCT_T2 p ON oi.product_id = p.id
    JOIN CATEGORY_T2 c ON p.category_id = c.id
    GROUP BY p.id, p.name, c.id, c.name
),
ranked_products AS (
    SELECT
        category_name,
        product_name,
        total_units_sold,
        ROW_NUMBER() OVER (PARTITION BY category_id ORDER BY total_units_sold DESC) AS rnk
    FROM product_totals
)
SELECT category_name, product_name, total_units_sold
FROM ranked_products
WHERE rnk <= 3
ORDER BY category_name, total_units_sold DESC;
