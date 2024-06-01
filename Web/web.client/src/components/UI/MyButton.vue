<template>
	<button class="button">
		<slot>
		</slot>
	</button>
</template>

<script>
export default {
	name: 'my-button',
}
</script>

<style scoped>
.button {
	padding: 8px 15px;
	background: none;
	border: 2px solid teal;
	border-radius: 5px;
	transition: 0.1s;
	cursor: pointer;
}
.button:hover {
	background-color: rgba(0, 128, 128, 0.17);
}
</style>